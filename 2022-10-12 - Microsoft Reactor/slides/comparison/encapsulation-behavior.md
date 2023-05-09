---
title: Encapsulation of behavior
---

# Encapsulation of behavior <MarkerCSharp />

```csharp {5-8|18}
public sealed class Foo
{
    public int Bar { get; set; }

    public int GetDoubleBar()
    {
        return Bar * 2;
    }
}

public static void Main()
{
    var foo = new Foo 
    { 
        Bar = 32,
    }
    
    var result = foo.GetDoubleBar();
}
```

---
hideInToc: true
---

# Encapsulation of behavior <MarkerRust />

```rust {5-12|16}
struct Foo
{
    pub bar: i32,
}

impl Foo 
{
    pub fn get_double_bar(&self) -> i32 
    {
        self.bar * 2
    }
}

pub fn main() {
    let foo = Foo { bar: 32 };
    let result = foo.get_double_bar();
}
```