#include <iostream>
#include <string>

using namespace std;

const int kBufferSize = 1024;

int main(int argc, char** argv)
{
  char buffer[kBufferSize + 1];
  cin.getline(buffer, kBufferSize);

  cout << "***" << buffer << "***" << endl;

  string myString;
  std::getline(cin, myString);

  cout << "***" << myString << "***" << endl;
}
