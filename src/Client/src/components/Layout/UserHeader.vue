<script setup lang="ts">

</script>

<template>
  <div class="flex justify-between px-3 py-2 items-center">
    <div>
      <p class="font-bold text-surface-600 dark:text-surface-300">
        Admin Panel
      </p>
    </div>
    <Button :icon="`pi ${isDark ? 'pi-sun' : 'pi-moon'}`" text @click="toggleDark()" />
  </div>
</template>
