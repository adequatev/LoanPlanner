#### how to run

##### 1. build an image

```bash
docker build -t loanplanner -f LoanPlanner.Web/Dockerfile .
```

##### 2. run container
```bash
docker run -p 8080:8080 --name loanplanner-container loanplanner
```
> HostPort:ContainerPort ->  HostPort can be set any free

##### 3. open the web page
```
http://localhost:8080
```
