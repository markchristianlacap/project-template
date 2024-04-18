<script setup lang="ts">
const userStore = useUserStore()
const user = computed(() => userStore.user)
</script>

<template>
  <div class="flex-1 rounded p-5 shadow dark:bg-surface-900">
    <p>
      Hello, {{ user?.name }}
    </p>
  </div>
</template>
