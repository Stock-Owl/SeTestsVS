#include "input.h"

char charcode_to_char(int charcode)
{
    switch (charcode)
    {

    }
}

std::string _input()
{
    std::string str = "";
    std::string ch = "";
    while (1)
    {
        ch = _getch();
        str += ch;
    }
    return str;
}

enum charcodes
{

};