<script lang="ts">
    import UserStatusBadge from "./UserStatusBadge.svelte";

    export let tableName;
    export let email;
    export let plan;
    export let mmr;
    export let onEdit = () => {};
</script>

<tr class="even:bg-gray-50 dark:even:bg-gray-900/50">
    <td class="p-3">
        <p class="font-medium">{tableName}</p>
    </td>
    <td class="p-3 text-gray-500 dark:text-gray-400">{email}</td>
    <td class="p-3">
        <UserStatusBadge status={plan} />
    </td>
    <td class="p-3 text-right">${mmr}</td>
    <td class="p-3 text-center">
        <button
                type="button"
                class="inline-flex items-center justify-center gap-2 rounded-lg border border-gray-200 bg-white px-2 py-1 text-sm font-semibold leading-5 text-gray-800 hover:border-gray-300 hover:text-gray-900 hover:shadow-sm focus:ring focus:ring-gray-300/25 active:border-gray-200 active:shadow-none dark:border-gray-700 dark:bg-gray-800 dark:text-gray-300 dark:hover:border-gray-600 dark:hover:text-gray-200 dark:focus:ring-gray-600/40 dark:active:border-gray-700"
                on:click={onEdit}>
            Edit
        </button>
    </td>
</tr>
