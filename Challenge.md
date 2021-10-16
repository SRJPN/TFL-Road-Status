# TfL Coding Challenge

## Overview of API

TfL maintains an open data REST API at https://api.tfl.gov.uk 

In order to use it you will need to register for a developer key here: https://api-portal.tfl.gov.uk/ 

Amongst the data available is the status of major roads. Some examples of this are shown below.

Example 1: Valid Road 

To get the status of the A2 (a major road in East London) you would make an HTTP GET request to `https://api.tfl.gov.uk/Road/A2?app_id=your_app_id&app_key=your_developer_key`
(where ‘your_app_id’ and ‘your_developer_key’ are the values sent to you by TfL when you register as a developer).

This call will return a ‘200’ response code along with the following JSON: -

``` json
[
  {
    "$type": "Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities",
    "id": "a2",
    "displayName": "A2",
    "statusSeverity": "Good",
    "statusSeverityDescription": "No Exceptional Delays",
    "bounds": "[[-0.0857,51.44091],[0.17118,51.49438]]",
    "envelope": "[[-0.0857,51.44091],[-0.0857,51.49438],[0.17118,51.49438],[0.17118,51.44091],[-0.0857,51.44091]]",
    "url": "/Road/a2"
  }
]
```

Example 2: Non-existent road

If you made a HTTP GET request to call to `https://api.tfl.gov.uk/Road/A233?app_id=your_app_id&app_key=your_developer_key`

You call will return a ‘404’ response code the following response: -

``` json
{
  "$type": "Tfl.Api.Presentation.Entities.ApiError, Tfl.Api.Presentation.Entities",
  "timestampUtc": "2017-11-21T14:37:39.7206118Z",
  "exceptionType": "EntityNotFoundException",
  "httpStatusCode": 404,
  "httpStatus": "NotFound",
  "relativeUri": "/Road/A233",
  "message": "The following road id is not recognised: A233"
}
```

## Exercise

### Task

We would like you to build a simple console application. This should work as follows: -


> Given a valid road ID is specified
> 
> When the client is run
> 
> Then the road ‘displayName’ should be displayed

> Given a valid road ID is specified
> 
> When the client is run
> 
> Then the road ‘statusSeverity’ should be displayed as ‘Road Status’

> Given a valid road ID is specified
> 
> When the client is run
> 
> Then the road ‘statusSeverityDescription’ should be displayed > as ‘Road Status Description’

> Given an invalid road ID is specified
> 
> When the client is run
> 
> Then the application should return an informative error

> Given an invalid road ID is specified
> 
> When the client is run
> 
> Then the application should exit with a non-zero System Error > code

Examples of this behaviour can be seen below: - 

``` powershell
PS C:\> .\RoadStatus.exe A2
The status of the A2 is as follows
        Road Status is Good
        Road Status Description is No Exceptional Delays

PS C:\> echo $lastexitcode
0

PS C:\> .\RoadStatus.exe A233
A233 is not a valid road
PS C:\> echo $lastexitcode
1
```

### Approach

* You may wish to use BDD and/or TDD in your answer.
* Please use C# .NET Framework or .NET Core
* Your code should be submitted as either of the following: -
  * As a Zip File via email (stripped of all binaries and intermediate build objects (otherwise it will be blocked by our email system) 
  * As a link to publicly accessible area such as a GitHub repository or DropBox.
* You should supply instructions in Markdown format in a file called ["README.md"](Readme.md). These should contain details of: -
  * How to build the code
  * How to run the output
  * How to run any tests that you have written
  * any assumptions that you’ve made
  * anything else you think is relevant

It should be possible to configure your application to use a different App ID and API key. You should ensure that yours are removed from the source code before you submit it and instructions are included in the readme file as how to change these.

Good luck and happy coding ☺
