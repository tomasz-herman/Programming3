#include <print>

void AssignString()
{
    char ub[] = "Hello, undefined!";
}

void PrintSomething()
{
    char greeting[16];
    std::println("{}", greeting);
}

int main()
{
    AssignString();
    PrintSomething();
    return 0;
}
