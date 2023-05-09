---
title: Null handling
---

# Null handling <MarkerCSharp />

```csharp {14-21|3|4-7|8-11}
public static void Main() 
{
    var result = GetNumberAsString(32);
    if (result == null) 
    {
        Console.WriteLine("No string representation!");
    } 
    else 
    {
        Console.WriteLine(result);
    }
}

public static string? GetNumberAsString(int number) 
{
    if (number == 0)
    {
        return "Zero";
    }
    return null;
}
```

---
hideInToc: true
---

# Null handling <MarkerRust />

Remember, <code style="font-size: 1.0em !important;">null</code> is not a thing in Rust.

<v-click>
```rust {10}
fn main() 
{
    let result = get_number_as_string(32);
    match result {
        Some(text) => println!("{}", text),
        None => println!("No string representation!"),
    }
}

pub fn get_number_as_string(value: i32) -> Option<String> 
{
    if value == 0 {
        return Some("Zero".to_string());
    }
    None
}
```
</v-click>

---
---

# Null handling <MarkerRust />

<code style="font-size: 1.0em !important;">Option</code> is a discriminated union.

```rust
pub enum Option<T> {
    Some(T),
    None,
}
```

---
---

# Null handling <MarkerRust />

Remember, <code style="font-size: 1.0em !important;">null</code> is not a thing in Rust.

```rust {10|12-14|15|3|4|5|6}
fn main() 
{
    let result = get_number_as_string(32);
    match result {
        Some(text) => println!("{}", text),
        None => println!("No string representation!"),
    }
}

pub fn get_number_as_string(value: i32) -> Option<String> 
{
    if value == 0 {
        return Some("Zero".to_string());
    }
    None
}
```