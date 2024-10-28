<template>
  <div class="input-field">
    <label :for="id" class="floating-label" :class="{ 'label-active': modelValue }">{{ label }}</label>
    <input
      :type="type"
      :id="id"
      :placeholder="placeholder"
      :aria-label="ariaLabel"
      :v-model="modelValue"
      @input="$emit('update:modelValue', $event.target.value)"
      class="input-field-input"
      required
    />
  </div>
</template>

<script>
export default {
  name: 'InputField',
  props: {
    type: {
      type: String,
      default: 'text'
    },
    id: {
      type: String,
      required: true
    },
    label: {
      type: String,
      default: ''
    },
    placeholder: {
      type: String,
      default: ''
    },
    ariaLabel: {
      type: String,
      default: 'Input field'
    },
    modelValue: {
      type: String,
      default: ''
    }
  }
}
</script>

<style scoped>
.input-field {
  position: relative;
  display: flex;
  flex-direction: column;
}

.floating-label {
  position: absolute;
  top: 50%;
  left: 10px;
  transform: translateY(-50%);
  transition: all 0.2s ease;
  background-color: white;
  padding: 0 4px;
  font-size: 16px;
  color: #aaa;
  pointer-events: none;
}

.label-active {
  top: -10px;
  left: 8px;
  font-size: 12px;
  color: #333;
}

.input-field-input {
  padding: 12px 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 16px;
  width: 100%;
  box-sizing: border-box;
  transition: border-color 0.2s ease;
}

.input-field-input:focus {
  outline: none;
  border-color: #007BFF;
}
</style>
