using System;
using Microsoft.Azure.WebJobs.Description;

namespace Inators.Azure.WebJobs.Extensions.Inject
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
    }
}