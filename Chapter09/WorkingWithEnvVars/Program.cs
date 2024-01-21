string myComputer = "My username is %USERNAME%. My CPU is %PROCESSOR_IDENTIFIER%.";
WriteLine(ExpandEnvironmentVariables(myComputer));

string pass = "hola";
SetEnvironmentVariable(pass, "Hola");
