---
title: Variables&colon; Shadowing
---

<!------------------------------------------------------------------------------>
<!-- VARIABLES: SHADOWING -->
<!------------------------------------------------------------------------------>

# Variables: Shadowing <MarkerRust />

```rust {2-3|5-6}
fn main() {
    let foo = 0;
    do_magic(foo);
    
    let foo = 32.0f32;
    reticulating_splines(foo);
}
```

<br />
<div v-click>
    <span class="text-gray-500">Not as bad as it sounds.</span><br />
    <span class="text-green-500">Actually pretty useful!</span>
</div>