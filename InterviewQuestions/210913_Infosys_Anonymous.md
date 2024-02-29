# 2021 09 13 Interview Questions (Infosys)

## Interview 1
1. What have you done in your career or talk about your projects.
2. Differnce between MVC and .NET Framework?
3. How would you write a function that returns whether it's an anagram.
Ex : "ACT" "TAC" => true
     "MAT" "CAT" => false
4. REST vs SOAP API
5. Pillars OOPS
6. What are the different types of inheritance?
7. Can a Controller have same method name for a different action?
8. Lets say you have a model for customer? how would you write a code that makes it name property required? And what's the header that makes it work?
Continuation: Lets say you have a Country field, and State Field which is required when a country is selected. How would you go about writing that code? 
Answer : You can use [RequiredIf] annotation.
9. 
```c#
class A 
  {
     int abc;
     int xyz;
  }

   class B : A
  {
    private int Calculate()
    {
      return abc + xyz;
    }
  }

Main () {

    B objB = new B();
    objB.abc = 10;
    objB.xyz = 2;
    A objA = new A();
    Console.WriteLine (objB.Calculate());
    Console.WriteLine ("Hello World");
  }
}
```
Will this run or throw error? What would be the output?

## Interview 2
1) CSS Box Model, Margin, Padding, and Absolute/Relative positioning.
2) Angular Lifecycle Hooks, Modules, and Components
3) The syntax to open an Angular application and make a new angular project (ng serve, ng new)
4) C# OOP pillars (inheritance)
5) ASP .NET questions about Local Storage and Session Storage
6) SQL questions about normalization, sql views, sql indexes, and inner outer join.

## Interview 3
OOP, SQL(DDL vs. DML, Join, TOP, FK, PK), Normalization, Angular (Lifestyle Hooks, Directives, CLI Commands)
Behavioral: Best Accomplishment, What motivates you

## Interview 4
1. What is a constructor?
2. Difference between abstract class and interface
3. What is the use of an interface and an abstract class
4. Types of constructors
5. What are Access modifiers?
6. What is static and its use?
7. How would you write a constructor?
8. What is a Primary Key?
9. What is a Foreign Key?
10. If you have two tables Employee(columns: id and name) and Department(columns: id and name), how would you use the primary and foreign keys to join them?
11. What is a left join?
12. What is a clustered and non-clustered index?
13. Write a query that returns the third highest salary from a table?
14. What is view state?
15. Different view state management techniques
16. How would you achieve input validation in ASP.NET?

## Interview 5
1. Tell me about inheritance in C#
2. Does it support multiple inheritance?
3. How about multiple interface inheritance?
4. Difference between abstract class and virtual?
5. Difference between arrays and lists?
6. Best practices for exception handling?
7. Can you have multiple catch blocks?
8. Difference between constant and readonly?
9. Can you have multiple constructors in C#?
10. What are some events in ASP.NET (i.e. its lifecycle)?
11. Tell me about garbage collection.
12. What happens when you compile code in C#?
13. What is assembly in C#?
14. Write a code down on paper that will take an input list, count how many times an element appears in that list, and then output ONLY the elements that appear more than once, including the count itself.
15. Write a SQL query on paper that will read from a table named User with columns "username" and "userid" and return another table with columns "username" and "username count" to count how many times a username appears in the User table.
16. How do you create a data access layer using Entity Framework?
17. How do you create database objects?
18. What does migration do?

## Interview 6
- Tell me about yourself
- What is the order of the css box model?
- How would you add a link in html?
- How would you add an image that opens a new window when clicked?
- What are arrow functions in Angular?
- What are modules in angular?
- What are services in angular?
- What are observables in angular?
- How would you implement a button that hides paragraphs when clicked?
- Whats the difference between javascript and typescript?
- What is the name of things like ngIf/ngFor/ngSwitch?
- What are the parts of an angular component?
- Name and explain different position properties
- What is encapsulation?
- How would you use encapsulation?
- What are abstract classes?
- What is an interface?
- What is a viewbag?
- What does MVC stand for?
- What are access modifiers?
- Whats the difference between private and protected?
- What are partial views and when would you use one?
- Name the kinds of joins in SQL
- What's the difference between a left and right join?
- Can you write a query that deletes a specific user for me?
- What indexes in SQL?
- What are views in SQL?

## Interview 7
- Tell me about yourself
- Talk about a project where you used c#
- What are ref and out?
- What is the difference between an abstract class and an interface?
- What is the difference between constant and readonly?
- How does multiclass inheritance in C#?
- How do you create something in SQL?
- What kinds of joins are  used in SQL?
- Tell me about the types of indexes available to you in SQL?
- Did you use LinQ to query the database? Do you know another method to do that?
- Which do you prefer Code first or Database first?
- What is the architecture of MVC?
- What are some exceptions or issues you've faced and how did you resolve them?
- How would you get data from a controller to a view?
- Your resume says you majored in creative writing. What is that all about?

## Interview 8
- Your name and what were the last projects you worked on?
- What kind of Sql did you use?
- Why would you want to use postgreSQL for store project?
- SQL DDL. DML questions
- SQL Index
- How would you update a database through C#
- The difference b/w delete truncate and drop
- What is rollback and have you used it?
- What is AOT?
- How do you use ADO.NET?
- MVC and how does it work?
- Partical View when have you used it
- Angular Model, Compoenents, servers and how you use them in a project
- What framework did you use to connect the database to c# (He did not accept EF Framework)
- How did you use Kubernetes with Azure
- What do you do to get data from an API in Cacophony
- Tell me about CICD and how you have used them in projects
- GIT command lines
- Have you testing in angular and explain how you tested them.
- What is REST?
- How many people did you work with in each project?
- He ask more Azure specific questions of these I never heard of

## Interview 9
- What are the names of components in Angular?
- What is bootstrap?
- What is ADO.NET?
- Can you use access modifiers in an interface?
- Array vs arraylist?
- what is JIT?
- What is foreign key?
- What is the difference between primary and foreign key?(wanted me to expand on that a lot)
- Difference between boxing and unboxing
- How to assign a data type? object?
- How did you use entityframework methods?
- How did you communicate with database?
- What is unmanaged code?
- Which version of angular are you using?

## Interview 10
* Tell me about your history in IT
    * (Cut me off after I talked about P2, how rude!)
* 4P: Inheritance
* SOLID principles
* SQL Indexes
* Foreign Key
* SQL Functions
* Method Overloading
* Method Overriding
* 4P: Polymorphism
* Interface vs Abstract
* Multiple Inheritance
* Normalizations
* SQL Views
* SQL Joins
* Catch Block Questions
* What is Entity Framework

