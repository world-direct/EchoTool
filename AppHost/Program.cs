using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var tcpEchoServuer = builder.AddProject<EchoTool>("TcpEchoServer").WithArgs("/p tcp", "/s 4578");
builder.AddProject<EchoTool>("TcpEchoClient").WithArgs("127.0.0.1", "/p tcp", "/r 4578", "/d 01234").WaitFor(tcpEchoServuer);

var udpEchoServuer = builder.AddProject<EchoTool>("UdpEchoServer").WithArgs("/p udp", "/s 4579");
builder.AddProject<EchoTool>("UdpEchoClient").WithArgs("127.0.0.1", "/p udp", "/r 4579", "/d 01234").WaitFor(udpEchoServuer);

builder.Build().Run();
