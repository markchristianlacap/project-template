<script setup>

</script>

<template>
  <UserHeader />
  <div class="border-b dark:border-surface-600 mb-4" />
  <div class="flex gap-5 mx-5">
    <div>
      <Sidebar />
    </div>
    <RouterView />
  </div>
</template>
