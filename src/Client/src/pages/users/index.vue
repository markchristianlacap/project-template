<script setup lang="ts">
import type { UserRowRes, UserStoreReq, UserUpdateReq } from '~/api/users'
import { usersApi } from '~/api/users'
import { Role } from '~/enums/role'

type IForm = UserStoreReq & UserUpdateReq
const { fetchRequest, loading, onPage, onSort, response } = useApiPagedReq(usersApi.getPaged)
const dialog = ref(false)
const form = ref<IForm>({} as IForm)
const id = ref<string>()
function create() {
  dialog.value = true
  id.value = ''
  form.value = { email: '', name: '', password: '', isActive: true, role: Role.User }
}
function edit(data: UserRowRes) {
  id.value = data.id
  form.value = {
    email: data.email,
    isActive: data.isActive,
    name: data.name,
    role: data.role,
  } as IForm
  dialog.value = true
}

onMounted(() => {
  fetchRequest()
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

    <DataTable
      :value="response?.rows"
      lazy
      paginator
      :rows="response?.rowsPerPage"
      :total-records="response?.rowsCount"
      :loading="loading"
      @page="onPage"
      @sort="onSort"
    >
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

    <UserDialogForm :id="id" v-model:dialog="dialog" v-model:form="form" @success="fetchRequest" />
  </div>
</template>UserStoreReq, UserUpdateReq,
