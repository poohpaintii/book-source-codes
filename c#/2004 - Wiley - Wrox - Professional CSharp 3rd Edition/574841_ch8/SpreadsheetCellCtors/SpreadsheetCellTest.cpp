#include "SpreadsheetCell.h"
#include <iostream>
using namespace std;

int main(int argc, char** argv)
{
  SpreadsheetCell myCell(5), anotherCell(4);

  cout << "cell 1: " << myCell.getValue() << endl;
  cout << "cell 2: " << anotherCell.getValue() << endl;

  SpreadsheetCell* myCellp = new SpreadsheetCell(5);
  SpreadsheetCell* anotherCellp;
  anotherCellp = new SpreadsheetCell(4);
  delete anotherCellp;

  SpreadsheetCell aThirdCell("test"); // uses string-arg ctor
  SpreadsheetCell aFourthCell(4.4);    // uses double-arg ctor
  SpreadsheetCell* aThirdCellp = new SpreadsheetCell("4.4"); // string-arg ctor
  cout << "aThirdCell: " << aThirdCell.getValue() << endl;
  cout << "aFourthCell: " << aFourthCell.getValue() << endl;
  cout << "aThirdCellp: " << aThirdCellp->getValue() << endl;

  delete aThirdCellp;

  return (0);
}
