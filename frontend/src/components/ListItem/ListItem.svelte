<script lang="ts">
    import {writable} from "svelte/store";
    import ConditionalLink from "../ConditionalLink/ConditionalLink.svelte";

    export let title = '';
    export let blurb = '';
    const _title = writable(title);
    const _blurb = writable(blurb);
    export let mode: "label" | "edit" | "new" = "label";
    export let link = '';
    export let onSubmit: ((title: string, blurb: string) => void) | undefined = undefined

    export let onDelete: (() => void) | undefined = undefined
    export let onCancel: (() => void) | undefined = undefined

    $: button1Label = {
        "edit": "Save",
        "new": "Save",
        "label": "Edit"
    }[mode];

    $: button2Label = {
        "edit": "Cancel",
        "new": "Cancel",
        "label": "Delete"
    }[mode];

</script>

<form
        class="flex items-center justify-between space-x-2 rounded-lg bg-gray-100/75 p-4 dark:bg-gray-900/50"
        on:submit={() => onSubmit ? onSubmit($_title, $_blurb) : null}
>
  <ConditionalLink active={mode === "label"} class="space-y-1" link={link}>
    {#if mode === "label"}
      <h4 class="font-semibold">{$_title}</h4>
    {:else}
      <div class="space-y-1">
        <label for="password" class="font-medium">Title</label>
        <input
                type="text"
                class="block w-full rounded-lg border border-gray-200 px-3 py-2 leading-6 placeholder-gray-500 focus:border-blue-500 focus:ring focus:ring-blue-500 focus:ring-opacity-50 dark:border-gray-600 dark:bg-gray-800 dark:placeholder-gray-400 dark:focus:border-blue-500"
                bind:value={$_title}
        />
      </div>
    {/if}

    {#if mode === "label"}
      <p class="text-sm text-gray-600 dark:text-gray-400">
        {$_blurb}
      </p>
    {:else}
      <div class="space-y-1">
        <label for="password" class="font-medium">Description</label>
        <textarea
                rows="4"
                class="block w-full rounded-lg border border-gray-200 px-5 py-3 leading-6 placeholder-gray-500 focus:border-blue-500 focus:ring focus:ring-blue-500 focus:ring-opacity-50 dark:border-gray-600 dark:bg-gray-800 dark:placeholder-gray-400 dark:focus:border-blue-500"
                bind:value={$_blurb}
        />
      </div>
    {/if}
  </ConditionalLink>
  <div class="flex-none">
    {#if onSubmit}
      <button
              type="button"
              class="inline-flex items-center justify-center space-x-1 rounded-lg border border-gray-200 bg-white px-3 py-2 text-sm font-semibold leading-5 text-gray-800 hover:border-gray-300 hover:text-gray-900 hover:shadow-sm focus:ring focus:ring-gray-300 focus:ring-opacity-25 active:border-gray-200 active:shadow-none dark:border-gray-700 dark:bg-gray-800 dark:text-gray-300 dark:hover:border-gray-600 dark:hover:text-gray-200 dark:focus:ring-gray-600 dark:focus:ring-opacity-40 dark:active:border-gray-700"
              on:click={mode === "label" ? () => mode = "edit" : () => {
                    if (onSubmit) onSubmit($_title, $_blurb)
                    mode = "label"
                }}
      >
        {button1Label}
      </button>
    {/if}
    {#if onDelete || onCancel}
    <button
            type="button"
            class="inline-flex items-center justify-center space-x-1 rounded-lg border border-gray-200 bg-white px-3 py-2 text-sm font-semibold leading-5 text-gray-800 hover:border-gray-300 hover:text-gray-900 hover:shadow-sm focus:ring focus:ring-gray-300 focus:ring-opacity-25 active:border-gray-200 active:shadow-none dark:border-gray-700 dark:bg-gray-800 dark:text-gray-300 dark:hover:border-gray-600 dark:hover:text-gray-200 dark:focus:ring-gray-600 dark:focus:ring-opacity-40 dark:active:border-gray-700"
            on:click={() => {
                    if (mode === "label") {
                        if (onDelete) onDelete()
                    } else if (mode === "edit") {
                        mode = "label"
                    } else {
                        blurb = ""
                        title = ""
                        if (onCancel) onCancel()
                    }

                }}
    >
      {button2Label}
    </button>
      {/if}
  </div>
</form>
