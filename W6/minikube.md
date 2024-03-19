# Minikube
Minikube is a local kubernetes cluster. It's a great way to play around with K8's locally without accruing a huge bill from your cloud service provider!

## How to get it working on windows...
1. Download minikube
2. Run Docker Desktop in Administrator mode
3. run `docker use context default`
4. run `minikube start --driver=docker`
   1. Otherwise it will try to use VM and issues will occur
5. run `minikube status` to confirm things are working
6. Now you have your own kubernetes cluster on your machine!

## How to get Ingress working on minikube
Ingress is not enabled by default in Minikube. To enable it, follow the next steps
- run `minikube addons enable ingress`
- run `minikube tunnel` your ingress is now available in 127.0.0.1
- run `kubectl get pods -n ingress-ngnix` to make sure your ingress resources are running
