using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectre.Presentation.Framework;

public interface IClicker
{
    bool HasActivity();
    ClickActivity WaitForActivity();
}

public enum ClickActivity
{
    None = 0,
    Previous,
    Next,
    Exit,
}
