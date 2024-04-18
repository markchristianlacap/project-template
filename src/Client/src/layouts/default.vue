<script setup>

</script>

<template>
  <main>
    <UserHeader />
    <div class="mb-4 border-b dark:border-surface-600" />
    <div class="mx-5 flex gap-5">
      <div>
        <Sidebar />
      </div>
      <RouterView />
    </div>
  </main>
</template>
