---
title: Error handling
---

# Error handling <MarkerCSharp />

```csharp
public static void Main() 
{
    try
    {
        DoMagic(32);
    }
    catch
    {
        // TODO: Handle
    }
}

public static string? DoMagic(int number) 
{
    throw new InvalidOperationException("Magic not available");
}
```

---
---

# Error handling <MarkerRust />

You return errors by returning <code style="font-size: 1.0em !important;">Result<T, E></code> and matching on them.

```rust {1-4|6-10}
enum Result<T, E> {
   Ok(T),
   Err(E),
}

let result = do_magic();
match result {
    Err(err) => println!("Error: {}", err),
    Ok(_) => println!("Success!");
}
```

---
---

# Error handling <MarkerRust />

```rust {1-7|9-21}
fn main() {
    let result = save_text("Hello Microsoft Reactor!");
    match result {
        Err(err) => println!("Could not write file: {}", err),
        Ok(()) => { },
    }
}

fn save_text(text: &str) -> Result<(), std::io::Error> {
    let file = std::fs::File::create("reactor.txt");
    match file {
        Err(e) => Err(e),
        Ok(mut file) => {
            let result = file.write_all(text.as_bytes());
            match result {
                Err(e) => return Err(e),
                _ => Ok(())
            }
        },
    }
}
```

---
---

# Error handling <MarkerRust />

```rust {9-12}
fn main() {
    let result = save_text("Hello Microsoft Reactor!");
    match result {
        Err(err) => println!("Could not write file: {}", err),
        Ok(()) => { },
    }
}

fn save_text(text: &str) -> Result<(), std::io::Error> {
    let mut file = std::fs::File::create("reactor.txt")?;
    file.write_all(text.as_bytes())
}
```