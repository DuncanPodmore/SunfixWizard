<script lang="ts">
    export let onSubmit = () => {}
</script>

<form class="space-y-6 dark:text-gray-100" on:submit={onSubmit}>
    <slot></slot>
</form>
