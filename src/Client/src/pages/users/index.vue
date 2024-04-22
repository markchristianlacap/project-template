<script setup lang="ts">
const users = ref({ rows: [] })
const loading = ref(false)
async function getUsers() {
  loading.value = true
  const res = await api.get('/users')
  users.value = res.data
  loading.value = false
}
const row = ref({})
const dialog = ref(false)
onMounted(() => {
  getUsers()
})
</script>

<template>
  <div class="mx-auto my-4 rounded bg-surface-0 pa-sm container dark:bg-surface-800">
    <div class="mb-3 flex items-center justify-between">
      <p class="text-lg font-bold">
        User Management
      </p>
      <Button label="Create" @click="dialog = true" />
    </div>
    <DataTable :value="users.rows" paginator :rows="1" :rows-per-page-options="[10, 20, 50]">
      <Column field="name" header="Name" class="text-nowrap">
        <template #editor="{ data, field }">
          <InputText v-model="data[field]" />
        </template>
      </Column>
      <Column field="email" header="Email" class="text-nowrap" />
      <Column field="createdAt" header="Created At" class="text-nowrap">
        <template #body="slotProps">
          {{ formatDate(slotProps.data.createdAt) }}
        </template>
      </Column>
      <Column field="updatedAt" header="Updated At" class="text-nowrap">
        <template #body="slotProps">
          {{ formatDate(slotProps.data.updatedAt) }}
        </template>
      </Column>
      <Column field="isActive" header="Status" class="text-nowrap">
        <template #body="{ data }">
          <InlineMessage :severity="data?.isActive ? 'success' : 'danger'">
            {{ data?.isActive ? 'Active' : 'Inactive' }}
          </InlineMessage>
        </template>
      </Column>
      <Column field="actions" header="Actions" class="text-nowrap">
        <template #body>
          <Button v-tooltip="`Edit User`" icon="pi pi-pencil" text />
          <Button v-tooltip="`Block User`" icon="pi pi-ban" text severity="danger" />
        </template>
      </Column>
    </DataTable>
    <UserDialogForm v-model:visible="dialog" v-model="row" />
  </div>
</template>
