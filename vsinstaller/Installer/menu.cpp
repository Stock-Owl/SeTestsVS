#include <iostream>
#include <string>
#include <conio.h>
#include <vector>
#include <cmath>
#include "menu.h"

using namespace Installer;

Menu::Menu(std::vector<std::string> options, std::vector<std::string> values)
{
    this->prompt = "";
    // resizes so both vectors are the same size
    if (options.size() != values.size())
    {
        if (options.size() > values.size())
        {
            int diff = options.size() - values.size();
            for (int i = 0; i < diff; ++i)
            {
                std::string value = "Filler value " + std::to_string(i);
                values.push_back(value);
            }
        }
        else
        {
            int diff = options.size() - values.size();
            for (int i = 0; i < diff; ++i)
            {
                std::string value = "Filler option " + std::to_string(i);
                options.push_back(value);
            }
        }
    }
    this -> size = options.size();  // could be values.size(), doesn't matter since they've been equalized
    this -> options = options;
    this -> values = values;
    this->selected_index = 0;
}

Menu::Menu(std::string prompt, std::vector<std::string> options, std::vector<std::string> values)
{
    this->prompt = prompt;
    // resizes so both vectors are the same size
    if (options.size() != values.size())
    {
        if (options.size() > values.size())
        {
            int diff = options.size() - values.size();
            for (int i = 0; i < diff; ++i)
            {
                std::string value = "Filler value " + std::to_string(i);
                values.push_back(value);
            }
        }
        else
        {
            int diff = options.size() - values.size();
            for (int i = 0; i < diff; ++i)
            {
                std::string value = "Filler option " + std::to_string(i);
                options.push_back(value);
            }
        }
    }
    this -> size = options.size();  // could be values.size(), doesn't matter since they've been equalized
    for (int idx = 0; idx < options.size(); ++idx)
    {
        this->options.push_back(options[idx]);
    }
    for (int idx = 0; idx < values.size(); ++idx)
    {
        this->values.push_back(values[idx]);
    }
    this->selected_index = 0;
}

std::string Menu::take_input()
{
    // ! DECLARATIONS
    // if the previous input was an arrowkey, then it is True
    std::string return_value;
    bool prevarrowkey = false;

    // this shit gets the index of the longest element because <algorithm>'s *max_element thinks that 17 > 19 is true
    int longest_element_index = 0;
    for (int i = 0; i < this->options.size(); ++i)
    {
        int current_length = this->options[i].size();
        int prev_length = this->options[longest_element_index].size();
        if (current_length > prev_length)
        {
            longest_element_index = i;
        }
    }

    // gets the longest element's length in the options vector (we will have to print that many spaces at the end)
    // afterprocessing the input, it prints as any spaces as
    // the longest element in all lines, effectively cleaning the console
    std::string longest_element = this->options[longest_element_index];
    std::string line_count;
    // std::cout << longest_element << longest_element.size() << std::endl;
    // +1 for the '>' selector character ('selector buffer')
    int max_line_length = longest_element.size() + 1;

    if (this->prompt != "")
    {
        line_count = std::to_string(this->size + 1);
        if (this->prompt.size() > max_line_length)
        {
            max_line_length = this->prompt.size();
        }
        std::cout << this->prompt << std::endl;
    }

    line_count = std::to_string(this->size);
    std::string lineclear(max_line_length, ' ');

    // ! DECLARATIONS END

    while (true)
    {
        for (int i = 0; i < this->size; ++i)
        {
            // using this because it will wrap around if the selected index 
            // becomes greater / smaller than the available range, hence the modulo
            int dynamic_index = this->selected_index % this->size;
            if (dynamic_index < 0) dynamic_index = this->size - std::abs(dynamic_index);
            if (dynamic_index == i) std::cout << "\033[38;5;15m>";
            else std::cout << " ";
            std::cout << options[i] << "\033[38;5;244m" << std::endl;
        }

        // goes back as many rows as many menu option there is
        std::cout << "\033[" << line_count << "A"; 

        int input = _getch();
        // using else-if-s so that you can break the while loop at certain cases
        if (prevarrowkey)
        {
            if (input == Menu::inputkeycodes::UP)
            {
                this->selected_index--;
                prevarrowkey = false;
            }
            else if (input == Menu::inputkeycodes::DOWN)
            {
                this->selected_index++;
                prevarrowkey = false;
            }
        }
        else if (input == Menu::inputkeycodes::ARROW_KEY_PREFIX)
        {
            prevarrowkey = true;
        }
        else if (input == Menu::inputkeycodes::ESC)
        {
            return_value = "";
            break;
        }
        else if (Menu::inputkeycodes::ENTER)
        {
            int index = this->selected_index % this->size;
            return_value = this->values[index];
            break;
        }

        // prints as many spaces as the longest element's length as many times as many menu option there is
        // then goes back on top
        for (int i = 0; i < size; ++i)
        {
            std::cout << lineclear << std::endl;
        }
        std::cout << "\033[" << line_count << "A"; 
    }

    // cleans shit up one more time before returning control
    for (int i = 0; i < size; ++i)
    {
        std::cout << lineclear << std::endl;
    }
    std::cout << "\033[" << line_count << "A"; 

    return return_value;
    delete &prevarrowkey;
    delete &return_value;
}
