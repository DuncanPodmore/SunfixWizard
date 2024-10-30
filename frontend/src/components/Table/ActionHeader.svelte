<script lang="ts">
    export let heading = "All Accounts";
    export let userCount = 5;
    export let actionText = "Add new user";
    export let onAction = () => {};
</script>

<div class="mb-5 flex flex-col gap-3 text-center sm:flex-row sm:items-center sm:justify-between sm:text-left">
    <div>
        <h3 class="mb-1 font-semibold">{heading}</h3>
        <h4 class="text-sm font-medium text-gray-500 dark:text-gray-400">
            You have
            <a href="javascript:void(0)" class="text-blue-600 hover:text-blue-400 dark:text-blue-400 dark:hover:text-blue-300">
                {userCount} user accounts
            </a>
        </h4>
    </div>
    <div class="flex items-center justify-center gap-2">
        <button
                type="button"
                class="inline-flex items-center justify-center gap-2 rounded-lg border border-blue-700 bg-blue-700 px-3 py-2 text-sm font-semibold leading-5 text-white hover:border-blue-600 hover:bg-blue-600 hover:text-white focus:ring focus:ring-blue-400/50 active:border-blue-700 active:bg-blue-700 dark:focus:ring-blue-400/90"
                on:click={onAction}>
            {actionText}
        </button>
    </div>
</div>
