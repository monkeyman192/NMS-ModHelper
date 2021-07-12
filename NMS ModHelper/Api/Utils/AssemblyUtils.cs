using System.Diagnostics;
using System.Reflection;

namespace NMS_ModHelper.Api.Utils
{
    public static class AssemblyUtils
    {
        // taken from https://www.codeproject.com/tips/791878/get-calling-assembly-from-stacktrace
        public static Assembly GetCallingAssemblyByStackTrace()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            StackTrace stackTrace = new StackTrace();
            StackFrame[] frames = stackTrace.GetFrames();

            foreach (var stackFrame in frames)
            {
                var ownerAssembly = stackFrame.GetMethod().DeclaringType.Assembly;
                if (ownerAssembly != thisAssembly)
                    return ownerAssembly;
            }
            return thisAssembly;
        }
    }
}
