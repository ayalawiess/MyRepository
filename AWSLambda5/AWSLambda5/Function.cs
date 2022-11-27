using Amazon.Lambda.ApplicationLoadBalancerEvents;
using Amazon.Lambda.Core;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambda5;

public class Function
{

    /// <summary>
    /// A simple function that takes a string and returns both the upper and lower case version of the string.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    //public string FunctionHandler(string input, ILambdaContext context)
    //{
    //    return "jjj";
    //   //return new Casing(input.ToLower(), input.ToUpper());
    //}


    //public ApplicationLoadBalancerResponse FunctionHandler(ApplicationLoadBalancerRequest request, ILambdaContext context)
    public ApplicationLoadBalancerResponse FunctionHandler(object input, ILambdaContext context)
    {
        //string xx= JsonSerializer.Serialize(input);
        string jsonText = input.ToString();
        Dictionary<string,int> values = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonText);
        
        Permutations per = new Permutations();
        string parmutationStr = per.PermutationsMain(values["val1"], values["val2"]);
        var response = new ApplicationLoadBalancerResponse
        {
            StatusCode = 200,
            StatusDescription = "200 OK",
            IsBase64Encoded = false
        };

        // If "Multi value headers" is enabled for the ELB Target Group then use the "response.MultiValueHeaders" property instead of "response.Headers".
        response.Headers = new Dictionary<string, string>
        {
            {"Content-Type", "text/html; charset=utf-8" }
        };
        
        response.Body =
@"
<html>
    <head>
        <title>Hello World!</title>
        <style>
            html, body {
                margin: 0; padding: 0;
                font-family: arial; font-weight: 700; font-size: 3em;
                text-align: center;
            }
        </style>
    </head>
    <body>
        <p>Hello World from message" + parmutationStr + @" My Lambda</p>
    </body>
</html>
";

        return response;
    }

}


public class Params
{
    public int val1 { get; set; }   
    public int val2 { get; set; }
}
//public record Casing(string Lower, string Upper);