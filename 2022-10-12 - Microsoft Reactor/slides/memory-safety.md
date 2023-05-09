---
title: Memory safety
layout: center
---

# Memory Safety

---
hideInToc: true
---

# Memory Safety

Rust's ownership model prevents bugs at compile time.

<v-click>
```rust {2|3|7|8|9|3|4}
fn main() {
    let name = "Reactor".to_string();
    greet(name);
    greet(name);
}

fn greet(name: String) {
    println!("Hello {}!", name);
}
```
</v-click>

<v-click>

<Error />
```
error[E0382]: use of moved value: `name`
 --> src\main.rs:4:11
```

</v-click>

---
hideInToc: true
---

# Memory Safety

The borrow checker

<v-click>
```rust {2|3|7|8|9|3|4}
fn main() {
    let name = "Reactor".to_string();
    greet(&name);
    greet(&name);
}

fn greet(name: &str) {
    println!("Hello {}!", name);
}
```
</v-click>

---
hideInToc: true
---

# Memory Safety

The borrow checker

```rust
fn main() {
    let name = "Reactor".to_string();
    greet(&name);
    greet(&name);
}

fn greet(name: &str) {
    println!("Hello {}!", name);
}
```

<br />
```text
Hello Reactor!
Hello Reactor!
```
