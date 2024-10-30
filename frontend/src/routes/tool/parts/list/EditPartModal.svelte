<script lang="ts">
    import type { Part } from "../../../../data/models";
    import {post, put} from "../../../../data/apiService";

    export let part: Part | null; // Part to edit, or null for a new one
    export let onDismiss = () => {};
    export let onSave = async () => {}; // Callback for after saving

    // Local state for the form inputs
    let partName: string = part ? part.name : "";
    let partType: string = part ? part.type : "";
    let partPrice: number = part ? part.price : 0;

    // Save the part (either add new or update)
    const savePart = async () => {
        const newPart: Part = {
            partId: part ? part.partId : 0,
            name: partName,
            type: partType,
            price: partPrice
        };

        // If part exists, update it; otherwise, create a new one
        if (part) {
            await put<Part>(`api/parts`, newPart.partId, newPart);
        } else {
            await post<Part>(`api/parts`, newPart);
        }

        await onSave(); // Trigger callback to refresh parts list
        onDismiss(); // Close modal
    };
</script>

<div
        tabindex="-1"
        role="dialog"
        class="fixed inset-0 z-90 overflow-y-auto overflow-x-hidden bg-gray-900/75 p-4 backdrop-blur-sm lg:p-8"
>
    <div
            role="document"
            class="mx-auto flex w-full max-w-7xl flex-col overflow-hidden rounded-lg bg-white shadow-sm dark:bg-gray-800 dark:text-gray-100"
    >
        <div class="flex items-center justify-between bg-gray-50 px-5 py-4 dark:bg-gray-700/50">
            <h3 class="flex items-center gap-2 font-medium">
                <span>{part ? `Edit ${part.name}` : 'Add Part'}</span>
            </h3>
            <div>
                <button
                        type="button"
                        class="inline-flex items-center justify-center gap-2 rounded-lg px-3 py-2 text-sm"
                        on:click={onDismiss}
                >
                    <svg
                            class="hi-solid hi-x inline-block size-4"
                            fill="currentColor"
                            viewBox="0 0 20 20"
                            xmlns="http://www.w3.org/2000/svg"
                            width={20}
                    >
                        <path
                                fill-rule="evenodd"
                                d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                                clip-rule="evenodd"
                        ></path>
                    </svg>
                </button>
            </div>
        </div>

        <div class="grow p-5">
            <label for="name" class="block mb-2 text-sm font-medium">Part Name</label>
            <input
                    id="name"
                    type="text"
                    bind:value={partName}
                    placeholder="Enter part name"
                    class="block w-full rounded-lg border px-3 py-2 mb-4 text-sm text-black placeholder:text-black"
                    required
            />

            <label for="type" class="block mb-2 text-sm font-medium">Part Type</label>
            <input
                    id="type"
                    type="text"
                    bind:value={partType}
                    placeholder="Enter part type"
                    class="block w-full rounded-lg border px-3 py-2 mb-4 text-sm text-black placeholder:text-black"
                    required
            />

            <label for="price" class="block mb-2 text-sm font-medium">Part Price</label>
            <input
                    id="price"
                    type="number"
                    bind:value={partPrice}
                    min="0"
                    step="0.01"
                    placeholder="Enter part price"
                    class="block w-full rounded-lg border px-3 py-2 text-sm text-black placeholder:text-black"
                    required
            />
        </div>

        <div class="space-x-1 bg-gray-50 px-5 py-4 text-right dark:bg-gray-700/50">
            <button
                    type="button"
                    class="inline-flex items-center justify-center gap-2 rounded-lg border px-3 py-2 text-sm"
                    on:click={onDismiss}
            >
                Cancel
            </button>
            <button
                    type="button"
                    class="inline-flex items-center justify-center gap-2 rounded-lg bg-blue-700 px-3 py-2 text-sm text-white"
                    on:click={savePart}
            >
                Save Part
            </button>
        </div>
    </div>
</div>
