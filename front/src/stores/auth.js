import { emptyForm, getFormData, validate } from "@/assets/js/helpers";
import { defineStore } from "pinia";
import { computed, ref } from "vue";
import { useAlertStore } from "./alert";
import http from "@/service/http";
import router from "@/router";

export const useAuthStore = defineStore("user", () => {
  const token = ref(localStorage.getItem("token"));
  const user = ref(localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")) : null);

  const setToken = (value) => {
    localStorage.setItem("token", value);
    token.value = value;
  };

  const setUser = (value) => {
    localStorage.setItem("user", JSON.stringify(value));
    user.value = value;
  };

  const isAuthenticated = computed(() => {
    // return token.value !== null;
    return user.value !== null;
  });

  const clear = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    token.value = null;
    user.value = null;
  };

  const login = async (values) => {
    if (!validate(values.target)) return;

    const data = getFormData(values.target);

    const user = {
      email: data.email,
      password: data.password,
    };

    const alertStore = useAlertStore();

    try {
      const { data, status } = await http.post("/login", user);

      // setToken(data.token);
      setUser(data);
      emptyForm(values.target);
      alertStore.successAlert("Login success");
      router.push({ name: "home" });
    } catch (error) {
      const status = error.response?.status || null;

      if (status === 401) {
        alertStore.dangerAlert("Email or password incorrect");
        return;
      }

      alertStore.dangerAlert("Something went wrong, please try again");
    }
  }

  const register = async (values) => {
    if (!validate(values.target)) return;
    const alertStore = useAlertStore();
    const data = getFormData(values.target);

    const user = {
      name: data.name,
      email: data.email,
      password: data.password,
    };

    try {
      await http.post("/register", user);
      alertStore.successAlert("Register success");
      router.push({ name: "login" });
    } catch (error) {
      const status = error.response?.status || null;
      if (status === 401) {
        alertStore.dangerAlert("User already exists");
        return;
      }

      alertStore.dangerAlert("Something went wrong, please try again");
    }
  }

  const contact = async (values) => {
    if (!validate(values.target)) return;

    const alertStore = useAlertStore();
    const data = getFormData(values.target);

    const message = {
      name: data.name,
      topic: data.topic,
      email: data.email,
      message: data.message,
    };

    try {
      await http.post("/contact", message);
      alertStore.successAlert("Message sent");
    } catch (error) {
      alertStore.dangerAlert("Something went wrong, please try again");
    }
  }

  const addPurchase = async (data) => {
    const alertStore = useAlertStore();
    console.log(data);
    const purchase = {
      productId: data.productId,
      userId: data.userId,
      quantity: data.quantity,
    }
  }

  const editUser = async (data) => {
    const alertStore = useAlertStore();
    
    const user = {
      name: data.name,
      email: data.email,
      phone: data.phone,
      address: data.address,
      city: data.city,
      state: data.state,
      CPF: data.cpf,
    }
  }

  const logout = () => {
    const alertStore = useAlertStore();

    router.push({ name: "login" });
    alertStore.successAlert("Logout success");
    clear();
  };

  return {
    token,
    user,
    isAuthenticated,
    setToken,
    setUser,
    clear,
    login,
    register,
    contact,
    logout,
    addPurchase
  };
});
