---
title: Conclusion&colon; Memory/Thread safety
---

# Memory & thread safety

Conclusion


<ul>
  <li v-click>The compiler enforces ownership</li>
  <li v-click>Every resource has exactly one owner</li>
  <li v-click>
    Others can borrow a resource from its owner
    <ul>
      <li>The owner cannot free or mutate resource while borrowed</li>
    </ul>
  </li>
  <li v-click>
    The owner can borrow resources to multiple borrowers
    <ul>
      <li>But only one mutable borrow at the time</li>
    </ul>
  </li>
  <li v-click>The owner can move ownership of the resource to someone else</li>
</ul>