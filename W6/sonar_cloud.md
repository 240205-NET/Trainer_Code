1. Get Sonar_token
    - In Sonar Cloud, navigate to my account -> security and generate a new token
    - Copy that token and create new github action secret called SONAR_TOKEN as your repository secret

2. Create a new workflow file (or modify an existing one) that contains the following code snippet
``` yml
jobs:
# Name of this job
  build:

# Which OS should this run on
    runs-on: windows-latest

# The actual instruction you give the machine to execute
    steps:
    # download your source code- equivalent to your git clone command
    - uses: actions/checkout@v3
      with:
          fetch-depth: 0  # Shallow clones should be disabled for a better relevancy of analysis
    # download .NET SDK to your runner
        
    - name: Set up JDK 11
      uses: actions/setup-java@v1
      with:
        java-version: 1.11
    - name: Cache SonarCloud packages
      uses: actions/cache@v1
      with:
        path: ~\sonar\cache
        key: ${{ runner.os }}-sonar
        restore-keys: ${{ runner.os }}-sonar
    - name: Cache SonarCloud scanner
      id: cache-sonar-scanner
      uses: actions/cache@v1
      with:
        path: .\.sonar\scanner
        key: ${{ runner.os }}-sonar-scanner
        restore-keys: ${{ runner.os }}-sonar-scanner
    - name: Install SonarCloud scanner
      if: steps.cache-sonar-scanner.outputs.cache-hit != 'true'
      shell: powershell
      run: |
        New-Item -Path .\.sonar\scanner -ItemType Directory
        dotnet tool update dotnet-sonarscanner --tool-path .\.sonar\scanner
    # equivalent to doing dotnet restore in your commandline
    # dotnet restore will download all your dependencies and make sure all your project references are correctly configured
    # equivalent to doing npm install
    - name: Restore dependencies
      run: dotnet restore YOUR_APP_DIRECTORY
    # equivalent to you doing dotnet build
    - name: Build
      run: dotnet build --no-restore YOUR_APP_DIRECTORY
    # running dotnet test
    - name: Test
      run: dotnet test --no-build --verbosity normal YOUR_APP_DIRECTORY --collect:"XPlat Code Coverage" --logger trx -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=opencover

    - name: Build and analyze
      env:
        GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}  # Needed to get PR information, if any
        SONAR_TOKEN: ${{ secrets.SONAR_TOKEN }}
      shell: powershell
      run: |
        .\.sonar\scanner\dotnet-sonarscanner begin /k:"YOUR_PROJECT_KEY" /o:"YOUR_ORGANIZATION_NAME" /d:sonar.login="${{ secrets.SONAR_TOKEN }}" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.cs.opencover.reportsPaths="**/TestResults/**/coverage.opencover.xml" -d:sonar.cs.vstest.reportsPaths="**/TestResults/*.trx"
        dotnet build --no-restore YOUR_APP_DIRECTORY
        .\.sonar\scanner\dotnet-sonarscanner end /d:sonar.login="${{ secrets.SONAR_TOKEN }}"
```

3. Cross your fingers, run the pipeline, and hope for the best
4. If everything succeeds, you should see updated information on sonar cloud project page