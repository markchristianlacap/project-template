<script setup lang="ts">
const userStore = useUserStore()
const user = computed(() => userStore.user)
</script>

<template>
  <div class="dark:bg-surface-900 p-5 rounded flex-1 shadow">
    <p>
      Hello, {{ user?.name }}
    </p>
  </div>
</template>
