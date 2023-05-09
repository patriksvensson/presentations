---
title: Thread safety
---

# Thread Safety

Rust's borrow checker prevents data races at compile time.

```rust {8-10}
fn main() {
    let name = "Reactor".to_string();
    greet(&name);
    greet(&name);
}

pub fn greet(text: &str) {
    std::thread::spawn(|| {
        println!("Hello {}!", text);
    });
}
```

---
hideInToc: true
---

# Thread Safety

Rust's borrow checker prevents data races at compile time.

```rust
error[E0373]: closure may outlive the current function, but it borrows `text`, 
              which is owned by the current function

   -> src/main.rs:8:24
   |
8  |     std::thread::spawn(|| {
   |                        -- may outlive borrowed value `text`
9  |         println!("Hello {}!", text);
   |                               ---- `text` is borrowed here
   |
```