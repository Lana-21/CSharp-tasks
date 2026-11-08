using System;
using System.Collections.Generic;
using System.Text;

namespace Practice14
{
    public record Laptop(
    string Model,
    string Manufacturer,
    double Processor,
    int CoresCount,
    double Price,
    int Year
);
}
