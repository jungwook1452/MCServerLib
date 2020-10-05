◆ MCServer 사용 설명서 ◆

본 라이브러리는 마인크래프트 서버를 구동하는 .NET DLL 파일입니다.

긔 외에는 최소 및 최대 활당 메모리를 설정하거나 OP(관리자), 밴 플레이어, 아이피 차단, 화이트리스트를 보거나 서버 설정 파일(server.properties)에서 서버 설정들을 가져오거나 수정할 수 있는 등 다양한 기능이 들어있습니다.

기본적으로 서버를 구동하는 코드는 다음과 같습니다.

// 서버 JAR 파일만 설정하시면 됩니다. 컴퓨터에 설치되어 있는 자바를 확인하여 서버를 실행할 자바 경로를 가져옵니다.
MCServer server = new MCServer("(Server Core File)");
// 혹은 서버를 실행시킬 자바 경로를 설정하실 수 있습니다. (예 : %ProgramFiles%\Java\jre1.8.0_261)
//MCServer server = new MCServer("(Server Core File)", "(Java Setup Path)");
server.Start();

이 두줄이면 서버를 실행할 수 있습니다.
이렇게 되면 서버 GUI 창이 나오는데, GUI 창을 없애고 싶으면

server.NoGUI = true;

이렇게 하시면 됩니다. 그러면 아무것도 나오지 않습니다. 그럼 어떻게 서버로부터 로그를 가져올 수 있을까요? 바로 이벤트에 있습니다.

// 서버 로그 출력 이벤트
server.OutputReceived
// 서버 오류 출력 이벤트
server.ErrorDataReceived
// 서버 종료 시 발생하는 이벤트
server.Exited

이렇게 3개가 제공됩니다. ErrorDataReceived는 사용하지 않아도 문제없습니다. 서버 내에서 오류가 발생하면 서버 로그 출력 이벤트로 나오게 되므로 일반적으로 쓸모가 없습니다.

OutputReceived 이벤트의 경우 e.LogOutput에서 출력한 로그 내용을 가져올 수 있습니다.

OutputReceived와 ErrorDataReceived 이벤트는 작업 스레드를 이용하므로 그냥 이벤트 내에서 UI 컨트롤을 사용하면 크로스 스레드 문제가 발생할 수 있습니다.
(Exited 이벤트는 UI 스레드로 실행됩니다)

참고 : 이 라이브러리는 Windows Forms 같은 GUI 프로그램에 사용하시는 것을 추천합니다. 또한 예제 (프로젝트 포함)도 함께 들어있습니다.

서버에 명령어를 전송하는 메서드는

server.SendCommand("(전송할 명령어)");

이며, 몇몇 명령어를 메서드로 만들었습니다. (AddOP, DeleteOP, AddBan, AddBanIP 메서드 등)

그 외 기능들은 같이 참부된 예시를 참고하십시오.

프로그램을 종료하기 전에 서버에 종료 명령어를 보내주는 것이 중요합니다. 종료 명령어를 보내지 않고 종료되면, 서버 프로세스는 그대로 남게됩니다.
따라서 프로그램 종료 전에  server.Stop 메서드를 호출하거나 SendCommand로 서버에 stop 명령어를 보내세요. (Stop로 보내든 SendCommand로 보내든 Stop 메서드는 내부적으로 SendCommand를 호출합니다.)

사용 외부 라이브러리:
Newtonsoft.Json -  MIT License
YamlDotNet - MIT License
System.IO.Compression.ZipFile - Microsoft Software License (.NET Library) > https://dotnet.microsoft.com/en/dotnet_library_license.htm
