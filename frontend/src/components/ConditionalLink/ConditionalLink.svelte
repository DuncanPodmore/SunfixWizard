<script>
    export let active = false;
    export let link = '';
</script>

{#if active}
    <a class={$$props.class} href="{link}">
        <slot></slot>
    </a>
{:else}
    <span class={$$props.class}>
        <slot></slot>
    </span>
{/if}