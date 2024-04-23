<script setup>
const users = ref({ rows: [] })
const loading = ref(false)
const dialog = ref(false)
const row = ref({})

async function getUsers() {
  loading.value = true
  const res = await api.get('/users')
  users.value = res.data
  loading.value = false
}
function create() {
  row.value = {}
  dialog.value = true
}
function edit(data) {
  row.value = {
    id: data.id,
    name: data.name,
    email: data.email,
  }
  dialog.value = true
}
function sort(e) {
  console.log('sort', e)
}
onMounted(() => {
  getUsers()
})
</script>

<template>
  <div class="mx-auto my-4 container card">
    <div class="mb-3 flex items-center justify-between">
      <p class="text-lg font-bold">
        User Management
      </p>
      <Button label="Create" @click="create()" />
    </div>
    <DataTable lazy :value="users.rows" :loading="loading" :sort="sort">
      <Column field="name" header="Name" class="text-nowrap" sortable>
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
        <template #body="{ data }">
          <Button v-tooltip="`Edit User`" icon="pi pi-pencil" text @click="edit(data)" />
          <Button v-tooltip="`Block User`" icon="pi pi-ban" text severity="danger" />
        </template>
      </Column>
    </DataTable>
    <UserDialogForm v-model:dialog="dialog" v-model:form="row" @success="getUsers" />
  </div>
</template>
