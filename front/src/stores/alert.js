import { defineStore } from "pinia";

export const useAlertStore = defineStore("alert", () => {
  const alert = null;

  const createAlert = (type, message) => {
    const buttonClose = document.createElement("button");
    buttonClose.classList.add("btn-close");
    buttonClose.setAttribute("data-bs-dismiss", "alert");
    const alert = document.createElement("div");
    alert.classList.add(
      "alert",
      "alert-dismissible",
      "fade",
      "show",
      `alert-${type}`,
      "position-fixed",
      "bottom-0",
      "start-0",
      "m-3",
      "fs-5",
      "z-index-alert"
    );
    alert.textContent = message;
    alert.appendChild(buttonClose);
    document.documentElement.append(alert);
    setTimeout(() => alert.remove(), 6000);
  };

  const successAlert = (message) => {
    createAlert("success", message);
  };

  const dangerAlert = (message) => {
    createAlert("danger", message);
  };

  const warningAlert = (message) => {
    createAlert("warning", message);
  };

  return {
    successAlert,
    dangerAlert,
    warningAlert,
  };
});
