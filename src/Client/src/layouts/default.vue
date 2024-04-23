<script setup lang="ts">
import type { MenuItem } from 'primevue/menuitem'

const userStore = useUserStore()
const toast = useToast()
const router = useRouter()
const items = ref<MenuItem[]>([
  {
    label: 'Dashboard',
    route: '/user',
    icon: 'pi pi-home',
  },
  {
    label: 'Users',
    route: '/users',
    icon: 'pi pi-users',
  },
  {
    label: 'Logout',
    icon: 'pi pi-sign-out',
    command: async () => {
      await userStore.logout()
      toast.add({ severity: 'info', detail: 'Logout successfully' })
      router.push('/')
    },
  },
])
</script>

<template>
  <main>
    <Menubar :model="items" pt:root:class="!rounded-none">
      <template #start>
        <div class="flex items-center justify-center gap-2">
          <p class="border-r pr-2 text-2xl font-bold">
            ADMIN
          </p>
          <p class="text-xs">
            Panel
          </p>
        </div>
      </template>
      <template #item="{ item, props, hasSubmenu }">
        <router-link v-if="item.route" v-slot="{ href, navigate }" :to="item.route" custom>
          <a v-ripple :href="href" v-bind="props.action" @click="navigate">
            <span :class="item.icon" />
            <span class="ml-2">{{ item.label }}</span>
          </a>
        </router-link>
        <a v-else v-ripple :href="item.url" :target="item.target" v-bind="props.action">
          <span :class="item.icon" />
          <span class="ml-2">{{ item.label }}</span>
          <span v-if="hasSubmenu" class="pi pi-fw pi-angle-down ml-2" />
        </a>
      </template>
      <template #end>
        <Button :icon="`pi ${isDark ? 'pi-sun' : 'pi-moon'}`" text @click="toggleDark()" />
      </template>
    </Menubar>
    <RouterView />
  </main>
</template>
