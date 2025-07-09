using System;
using dotenv.net;
using P1_SqlDbConsole.Interfaces;

namespace P1_SqlDbConsole;

public struct EnvService : ILoadEnv
{
    public readonly string LoadEnv(string envVariable)
    {
        DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
        string ConnectionString = Environment.GetEnvironmentVariable(envVariable);
        return ConnectionString;
    }
}
