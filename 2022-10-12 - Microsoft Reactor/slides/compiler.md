---
layout: two-cols
title: Compiler
---

<!------------------------------------------------------------------------------>
<!-- COMPILATION -->
<!------------------------------------------------------------------------------>

# <MarkerCSharp />

<ul>
  <li v-click="1">Uses homebrewed tool chain</li>
  <li v-click="2">Compiles to CIL bytecode</li>
  <li v-click="3">
    JIT (Just-In-Time) compiled
    <ul>
      <li>RyuJit</li>
    </ul>
  </li>
  <li v-click="4">
    Supports AOT (Ahead-Of-Time) compilation
    <ul>
      <li>Native, architecture specific code</li>
      <li>Usually long lead time for new platform support</li>
      <li>Includes the .NET runtime</li>
    </ul>
  </li>
</ul>

::right::
# <MarkerRust />

<ul>
  <li v-click="1">
    Uses the LLVM toolchain
    <ul>
      <li>Widely used (Swift, Clang, etc)</li>
      <li>Synergistic effect for platform support</li>
    </ul>
  </li>
  <li v-click="2">Compiles to LLVM IR bytecode</li>
  <li v-click="3">
    AOT (Ahead-Of-Time) compiled
    <ul>
      <li>Native, architecture specific code</li>
      <li>Small binaries</li>
      <li>No runtime <small>(kind of)</small></li>
    </ul>
  </li>
</ul>