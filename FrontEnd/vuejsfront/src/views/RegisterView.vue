<template>
  <div class="register-container">
    <main class="register-content">
      <section class="image-section">
        <img
          loading="lazy"
          :src="
            require('@/assets/LoginView/95cd3ebe39f8704f12ee14178415e50d18f28074f59c83ce8ea6fe5f9c84cef1.png')
          "
          alt="Register illustration"
          class="register-image"
        />
      </section>
      <section class="form-section">
        <form @submit.prevent="handleRegister" class="register-form">
          <h2 class="form-title">REGISTRE-SE</h2>
          <div class="form-group">
            <InputField
              id="name"
              type="text"
              label="Nome:"
              placeholder="Nome"
              v-model="name"
              :error="errors.name"
            />
          </div>
          <div class="form-group">
            <InputField
              id="email"
              type="email"
              label="Email:"
              placeholder="Email"
              v-model="email"
              :error="errors.email"
            />
          </div>
          <div class="form-group">
            <InputField
              id="password"
              type="password"
              label="Senha:"
              placeholder="Senha"
              v-model="password"
              :error="errors.password"
            />
          </div>
          <div class="form-group">
            <InputField
              id="confirmPassword"
              type="password"
              label="Confirmar Senha:"
              placeholder="Confirmar Senha"
              v-model="confirmPassword"
              :error="errors.confirmPassword"
            />
          </div>
          <button type="submit" class="submit-button" :disabled="isLoading">
            {{ isLoading ? "REGISTRANDO..." : "REGISTRAR" }}
          </button>
          <p v-if="errorMessage" class="error-message">{{ errorMessage }}</p>
        </form>
      </section>
    </main>
  </div>
</template>

<script>
import InputField from "@/components/InputField.vue";

export default {
  components: {
    InputField,
  },
  data() {
    return {
      name: "",
      email: "",
      password: "",
      confirmPassword: "",
      errors: {},
      isLoading: false,
      errorMessage: "",
    };
  },
  methods: {
    handleRegister() {
      console.log(
        "Nome:",
        this.name,
        "Email:",
        this.email,
        "Senha:",
        this.password,
        "Confirmar Senha:",
        this.confirmPassword
      );
    },
  },
};
</script>

<style scoped>
.register-container {
  background-color: #fff;
  padding: 0 20px;
  overflow: hidden;
  max-width: 100vw;
  box-sizing: border-box;
}

.register-content {
  display: flex;
  flex-direction: row-reverse;
  justify-content: center;
  align-content: center;
  height: 100vh;
}

.image-section {
  width: 61%;
  max-width: 100%;
}

.register-image {
  aspect-ratio: 0.8;
  object-fit: contain;
  object-position: center;
  width: 100dvh;
  max-width: 100dvh;
  height: 100dvh;
  max-height: 100dvh;
}

.form-section {
  width: 39%;
  max-width: 100%;
  padding: 0 10px;
  display: flex;
  justify-content: center;
  align-items: center;
}

.register-form {
  border-radius: 15px;
  background-color: #fff;
  display: flex;
  flex-direction: column;
  color: #000;
  padding: 32px 20px 110px;
  font: 400 22px Inter, sans-serif;
  width: 100%;
  max-width: 400px;
}

.form-title {
  font-size: 35px;
  font-weight: 700;
  text-align: center;
  margin-bottom: 19px;
}

.form-group {
  margin-bottom: 29px;
}

.submit-button {
  border-radius: 32px;
  background-color: #272343;
  font-size: 18px;
  color: #fff;
  font-weight: 700;
  padding: 21px 70px;
  border: none;
  cursor: pointer;
}

@media (max-width: 991px) {
  .register-container {
    padding-right: 20px;
  }

  .register-content {
    flex-direction: column;
  }

  .image-section,
  .form-section {
    width: 100%;
  }

  .register-image {
    max-width: 100%;
    margin-top: 40px;
  }

  .register-form {
    max-width: 100%;
    margin-top: 40px;
    padding: 0 20px 100px;
  }

  .submit-button {
    white-space: normal;
    padding: 21px 20px;
  }
}

@media (max-width: 768px) {
  .register-form {
    padding: 0 10px 50px;
  }

  .submit-button {
    padding: 16px 10px;
  }
}
</style>
