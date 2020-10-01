/*main.cpp*/

//
// Chicago Crime Analysis program in modern C++.
//
// <<Justin Donayre>>
// U. of Illinois, Chicago
// CS 341: Spring 2018
// Project 02
//

#include <iostream>
#include <iomanip>
#include <fstream>
#include <string>
#include <sstream>
#include <vector>
#include <map>
#include <algorithm>

#include "classes.h"

using namespace std;

void read_crime_code(std::ifstream &codesFile, vector<CrimeCode> codes)
{
  string content, iucr, primary, secondary;
  getline(codesFile, content); // reads out the intro line
  getline (codesFile, content, ','); // reads IUCR
  while(1){
      iucr = content;
    getline (codesFile, content, ',');
      primary = content;
    getline (codesFile, content, ',');
      secondary = content;
    getline (codesFile, content, ',');
    
  }
}

int main()
{
  string  crimeCodesFilename, crimesFilename;

  cin >> crimeCodesFilename;
  cout << crimeCodesFilename << endl;
  
  cin >> crimesFilename;
  cout << crimesFilename << endl;

  ifstream  codesFile(crimeCodesFilename);
  ifstream  crimesFile(crimesFilename);

  cout << std::fixed;
  cout << std::setprecision(2);

  if (!codesFile.good())
  {
    cout << "**ERROR: cannot open crime codes file: '" << crimeCodesFilename << "'" << endl;
    return -1;
  }
  if (!crimesFile.good())
  {
    cout << "**ERROR: cannot open crimes file: '" << crimesFilename << "'" << endl;
    return -1;
  }
    
  vector<CrimeCode> crimecodes;
  map<string, CrimeCode> codemap;
  read_crime_code(codesFile, crimecodes);
 
   return 0;
}
