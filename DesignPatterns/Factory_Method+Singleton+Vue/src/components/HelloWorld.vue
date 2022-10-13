<script setup lang="ts">
import { onMounted, reactive, ref } from "vue";
import { Roles } from "../models/enums/Roles";
import { Menu } from "../models/factorymethod/base/Menu";
import { ExternalUserCreator } from "../models/factorymethod/impl/ExternalUserCreator";
import { UserMenuCreator } from "../models/factorymethod/impl/UserMenuCreator";
import Session from "../models/singleton/Session";

defineProps<{ msg: string }>();

const session = reactive(new Session());

const username = "Pablo Mederos"

const login = () => {
  session.setUserData({
    username,
  });

  createMenu();
};

const changeRoleToAdmin = () => {
  session.setUserData({
    username: session.username || username,
    role: Roles.ADMIN,
  });

  createMenu();
};

const changeRoleToOperator = () => {
  session.setUserData({
    username: session.username || username,
    role: Roles.OPERATOR,
  });

  createMenu();
};

const changeRoleToAuditor = () => {
  session.setUserData({
    username: session.username || username,
    role: Roles.AUDITOR,
  });

  createMenu();
};

let menu = ref<Menu>();

function createMenu() {
  const role = session.role;

  menu.value =
    role === Roles.NONE // El usuario sin rol es un usuario externo
      ? new ExternalUserCreator().CreateMenu()
      : new UserMenuCreator().CreateMenu(role);
}

onMounted(login);
</script>

<template>
  <h1>{{ msg }} <br> {{session.role == Roles.NONE ? 'Usuario Externo' : 'Usuario Interno'}} </h1>

  <ul v-if="menu">
    <li v-for="(option, i) in menu.Options" :key="i">
      <button @click="option.value">{{ option.key }}</button>
    </li>
  </ul>

  <div class="card">
    <button type="button" @click="changeRoleToAdmin">Rol a ADMIN</button>
    <button type="button" @click="changeRoleToOperator">Rol a OPERATOR</button>
    <button type="button" @click="changeRoleToAuditor">Rol a AUDITOR</button>
    <button type="button" @click="session.clearData">Usuario Externo</button>
  </div>
</template>

<style scoped>
.read-the-docs {
  color: #888;
}

span.role {
  border: 1px solid white;
  border-radius: 50%;
  padding: 10px;
}

.ext {
  color: white;
  background: red;
}

.int {
  color: white;
  background: rgb(3, 151, 35);
}

.card {
  display: inline-flex;
  gap: 1em;
}

ul {
  list-style: none;
}

li button {
  min-width: 200px;
  background: rgb(2, 0, 36);
  background: linear-gradient(
    90deg,
    rgba(2, 0, 36, 1) 0%,
    rgba(39, 121, 9, 1) 49%,
    rgba(0, 155, 255, 1) 100%
  );
  border: 1px solid white;

  margin  : 10px;
}
</style>
