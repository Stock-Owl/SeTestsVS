#include <iostream>
#include <stdlib.h>
#include <string>
// #include <direct.h>

int main(int argc, char* argv[])
{

    std::string cdpath = "powershell -Command \"Start-Process test.exe -Verb runAs\"";
    int cdin = system(cdpath.c_str());
    std::cout << cdin << std::endl;
    return 0;
}