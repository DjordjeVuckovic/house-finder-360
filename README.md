# House Finder 360

## About the Project

This project is about managing the house rental process. 
It aims to simplify the search for rental properties by providing users with a comprehensive platform to browse listings, filter by their preferences, and connect with landlords directly. 
Whether you're looking for a new home, our House Finder project makes it easier.

## System Architecture

The main technologies used in this project are .NET and React. 
For the backend, we have chosen a modular monolith architecture built with .NET. 
This approach makes our system solid yet flexible enough to grow. 
On the frontend, we built it using React and chose Vite as our building tool.

### System Architecture Diagram

Below is a C4 diagram that illustrates the overall architecture of the system, including how the frontend, backend, and database interact:

![System Diagram](/docs/house-finder.drawio.png)

In docs folder you can find more detailed view of the architecture.That folder also contains all the diagrams that are used in this project(architecture diagrams, sequence diagrams, etc.).

### Getting Started

If you are using docker, you can start the project by running the following command in the root directory:

```bash 
docker-compose up -f ./docker/docker-compose.yml -d
```
If you are not using docker you can start project with the following:

* This project uses PostgreSQL as a database. You can install it from [here](https://www.postgresql.org/download/).

After that step run the following commands in the root directory for the backend and frontend:

* Run backend:

```bash 
cd house-finder-be
```

Run main entrypoint of modular monolith:
```bash 
dotnet run --project ./HouseFinder360.Api
```

* Run frontend:

```bash 
cd house-finder-fe
```

```bash 
npm run dev
```

For the development purpose you can use the docker/docker-compose.dev.yml file that spin up all dev dependencies. 

### Technologies
- .NET Core 7
- React
- Docker
- Nginx


### Application ui pictures

![Landing page](/static/images/landing-page.png)
* Landing page


![Sign In page](/static/images/sign-in.png)
* Sign In page


![Your properties page](/static/images/your-properties.png)
* Page of Your properties


![Map view page](/static/images/map-view.png)
* Map view of properties


![Create property page](/static/images/create-property-1.png)
![Create property page](/static/images/create-property-2.png)
![Create property page](/static/images/create-property-3.png)
![Create property page](/static/images/create-property-4.png)
![Create property page](/static/images/create-property-5.png)
![Create property page](/static/images/create-property-6.png)
* Create property pages