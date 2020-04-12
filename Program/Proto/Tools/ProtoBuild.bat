
set PROTOGEN=%cd%\protogen\protogen.exe

cd..

set PROTOCOLPATH=%cd%\

set GAMEPROTO=%PROTOCOLPATH%GameProto.proto
set FIGHTPROTO=%PROTOCOLPATH%FightProto.proto

cd ..
set CLIENTDIR=%cd%\FrameSyncDemo\Assets\Script
set SVRDIR=%cd%\FrameSyncDemoSvrCSharp\FrameSyncDemoSvrCSharp

set CLIENTPROTOCOLFILE=%CLIENTDIR%\NetWork\Protocol\
set SVRPROTOCOLFILE=%SVRDIR%\NetWork\Protocol\

%PROTOGEN% -i:%GAMEPROTO% -o:%CLIENTPROTOCOLFILE%GameProto.cs -ns:FSD.Protocol
%PROTOGEN% -i:%FIGHTPROTO% -o:%CLIENTPROTOCOLFILE%FightProto.cs -ns:FSD.Protocol

%PROTOGEN% -i:%GAMEPROTO% -o:%SVRPROTOCOLFILE%GameProto.cs -ns:FSD.Protocol
%PROTOGEN% -i:%FIGHTPROTO% -o:%SVRPROTOCOLFILE%FightProto.cs -ns:FSD.Protocol