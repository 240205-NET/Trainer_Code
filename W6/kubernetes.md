# MSA / Kubernetes

## MSA : Microservices Architecture
- Monolithic architecture: all diff components/services are tightly coupled together, relies on everything being functional for the app to be functional. 
  - Pros: for small apps, proof of concepts/prototypes it has low overhead, low complexity to get the architecture going
  - Cons: super hard to scale. If one thing breaks, everything else does too!

- Service Oriented Architecture
  - Pros: More modular code. Increased redundancy/resiliency. Separate BE can serve multiple clients (Web app, mobile app, other programs, etc.) Flexible. Way better for maintaining/scaling. We can scale services separately. 
  - Cons: More overhead than monolith. More layers to the system. Communication complexity increases- more moving parts == more points of potential failures. Potential increase security concerns

- Micro Services Architure
  - You take your backend, and split it up to tiny, "microservice" that only are concerned about a particular feature set of the application.
  - Pros: even more modular -> SCALING, high reusability, easier to maintain -> highly decoupled system. 
  - Cons: high overhead to set up and manage

## Kubernetes: Container Orchestration Service
Think of K8's as a department manager. Each department has multiple teams, each concerned about different functions in the department. The teams in the department have a team lead that reports to department manager.
- Cluster: The department (manager, teams, team leads, team members, etc.)
- Control Plane: your dept manager office
- Pod: Is your team member (this is your tiny microservice, they are containers)
- Node: Is team office (this is a machine that pods live. A node can have 1+ pods)
- Kubectl: is CLI tool to interact with a K8's cluster
- Kubelet: is your team lead. Kubelet lives in the node, and communicates with control plane
- Ingress: Sales team, it's a technology that allows external traffic to this cluster
- Service: managment tools: logical grouping of pods
- Deployment: management tools: logical grouping of services and replica sets, etc.
- ... and more