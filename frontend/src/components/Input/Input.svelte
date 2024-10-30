<script lang="ts">
    export let label = "";
    export let value = "";
    export let onChange = (e: Event) => {};
</script>

<div class="space-y-1">
    <label for={label} class="font-medium">{label}</label>
    <input
            type="text"
            id={label}
            name={label}
            value={value}
            on:change={(e) => onChange(e)}
            placeholder={`Enter ${label}`}
            class="block w-full rounded-lg border border-gray-200 px-3 py-2 leading-6 placeholder-gray-500 focus:border-blue-500 focus:ring focus:ring-blue-500/50 dark:border-gray-600 dark:bg-gray-800 dark:placeholder-gray-400 dark:focus:border-blue-500"
    />
</div>
