<script setup>
const users = ref({})
const loading = ref(false)
async function getUsers() {
  loading.value = true
  const res = await api.get('/users')
  users.value = res.data
  loading.value = false
}
const currentUser = ref({})
const dialog = ref(false)
onMounted(() => {
  getUsers()
})
</script>

<template>
  <div class="w-full">
    <div class="flex justify-between">
      <p>
        Users
      </p>
      <Button label="Create" @click="dialog = true" />
    </div>
    <DataTable :value="users.rows" paginator :rows="1" :rows-per-page-options="[10, 20, 50]">
      <Column field="name" header="Name" />
      <Column field="email" header="Email" />
    </DataTable>
    <UserDialogForm v-model:visible="dialog" v-model="currentUser" />
  </div>
</template>
