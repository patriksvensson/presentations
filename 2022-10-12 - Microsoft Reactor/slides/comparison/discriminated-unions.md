---
title: Discriminated unions
---

# Discriminated unions <MarkerRust />

```rust
pub enum IpAddress
{
   V4(u8, u8, u8, u8),
   V6(String),
}
```

<div v-click>
<br />
```rust
match address {
  IpAddress::V4(a, b, c, d) => todo!(),
  IpAddress::V6(value) => todo!(),
}
```
</div>