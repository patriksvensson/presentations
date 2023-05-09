---
title: Variables&colon; Declarations
---

# Variables: Declaration <MarkerCSharp />

```csharp
int foo = 1;
foo = 2;
```

---
hideInToc: true
---

# Variables: Declarations <MarkerRust />

```rust
let foo: i32 = 0;
foo = 2;
```

<div v-click>

  <Error />
  ```
  error[E0384]: cannot assign twice to immutable variable `foo`
  --> src\main.rs:3:5
    |
  2 |     let foo = 0;
    |         ---
    |         |
    |         first assignment to `foo`
    |         help: consider making this binding mutable: `mut foo`
  3 |     foo = 2;
    |     ^^^^^^^ cannot assign twice to immutable variable
  ```
</div>

---
hideInToc: true
---

# Variables: Declarations <MarkerRust />

```rust {1}
let mut foo: i32 = 0;
foo = 2;
```

<Success />

```
   Compiling demo v0.1.0 (C:\Users\Patrik\Source\temp\demo)
    Finished dev [unoptimized + debuginfo] target(s) in 0.17s
```