<script lang="ts">

    let panelArray: number[][] = [];
    let isLoaded = false;

    // Input parameters
    let runOrientation: "Columns" | "Rows" = "Columns";
    let numPanels: number = 3;
    let panelOrientation: "Landscape" | "Portrait" = "Landscape";
    let railOrientation: "Parallel" | "Perpendicular" = "Parallel";
    let numRails: number = 1;
    let railContinuity: "Continuous" | "Short" = "Continuous";
    let panelLongDimension = 2400;
    let panelShortDimension = 1100;
    let panelThickness = 40;
    let numberOfRuns = 1;
    let scale = 10; // Scale factor to fit the layout on canvas
    $: getScale = scale / 100;

    // Canvas properties
    let canvas: HTMLCanvasElement;
    let ctx: CanvasRenderingContext2D;
    const canvasWidth = 1000;
    const canvasHeight = 1000;

    // Limit scale between 1 and 100
    function adjustScale(deltaY: number) {
        scale = Math.max(1, Math.min(scale - Math.floor(deltaY / Math.abs(deltaY)), 100)); // Adjust scale based on scroll
    }

    function getLongestArrayLength(arrays: any[][]): number {
        return arrays.reduce(
            (maxLength, currentArray) => Math.max(maxLength, currentArray.length),
            0
        );
    }

    //   onMount(() => {
    //     drawLayout(
    //       runOrientation,
    //       numPanels,
    //       panelOrientation,
    //       railOrientation,
    //       numRails,
    //       railContinuity,
    //       panelLongDimension,
    //       panelShortDimension,
    //       panelThickness,
    //       numberOfRuns,
    //       getScale,
    //       panelArray
    //     );
    //   });

    $: {
        if (!ctx && canvas) {
            console.log('runs ctx')
            // @ts-ignore
            ctx = canvas.getContext("2d")
        }

        console.log(ctx);
        if (ctx) {
            console.log('test 2')
            drawLayout(
                runOrientation,
                numPanels,
                panelOrientation,
                railOrientation,
                numRails,
                railContinuity,
                panelLongDimension,
                panelShortDimension,
                panelThickness,
                numberOfRuns,
                getScale,
                panelArray
            );
        }
    }

    function drawLayout(
        a: any,
        b: any,
        c: any,
        d: any,
        e: any,
        f: any,
        g: any,
        h: any,
        i: any,
        j: any,
        k: any,
        l: any
    ) {
        console.log('test');

        const result = calculateClamps(panelArray);

        // Clear canvas
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        // Calculate panel dimensions based on orientation
        const panelWidth =
            panelOrientation === "Landscape"
                ? panelLongDimension
                : panelShortDimension;
        const panelHeight =
            panelOrientation === "Landscape"
                ? panelShortDimension
                : panelLongDimension;

        // Calculate layout dimensions
        // const actualRows = Math.ceil(numPanels / panelsPerRow);
        // const layoutWidth = panelWidth * panelsPerRow;
        // const layoutHeight = panelHeight * actualRows;

        // Set canvas size
        canvas.width = 1000; //layoutWidth * getScale + 40;
        canvas.height = 1000; //layoutHeight * getScale + 40;

        // Draw panels
        let panelsDrawn = 0;
        // if (runOrientation === "Columns") {
        for (const [rIndex, run] of panelArray.entries()) {
            for (const [pIndex, _] of run.entries()) {
                if (runOrientation === "Columns") {
                    const x = rIndex * panelWidth;
                    const y = pIndex * panelHeight;
                    drawPanel(x, y, panelWidth, panelHeight);
                    drawRail(x, y, panelWidth, panelHeight);
                } else {
                    const x = rIndex * panelHeight;
                    const y = pIndex * panelWidth;
                    drawPanel(y, x, panelWidth, panelHeight);
                    drawRail(y, x, panelWidth, panelHeight);
                }

                panelsDrawn++;
            }
        }
        // } else {
        //   const maxLength = getLongestArrayLength(panelArray)
        //   for (let index = 0; index < maxLength; index++) {
        //     const element = array[index];

        //   }
        // }

        // Draw rails
        // drawRails(
        //   panelWidth,
        //   panelHeight,
        //   numberOfRuns,
        // );

        // // Draw clamps
        // drawClamps(
        //   panelWidth,
        //   panelHeight,
        // );
    }

    function drawPanel(x: number, y: number, width: number, height: number) {
        ctx.strokeRect(
            x * getScale + 20,
            y * getScale + 20,
            width * getScale,
            height * getScale
        );
    }

    const repeat = (times: number, callback: (i: number) => void) => {
        for (let i = 0; i < times; i++) {
            callback(i);
        }
    };

    function drawRail(
        x: number,
        y: number,
        panelWidth: number,
        panelHeight: number
    ) {
        ctx.strokeStyle = "red";
        if (
            (railOrientation === "Parallel" && runOrientation == "Columns") ||
            (railOrientation === "Perpendicular" && runOrientation == "Rows")
        ) {
            const gap = panelWidth / (numRails + 1);

            repeat(numRails, (i) => {
                if (railContinuity === "Continuous") {
                    const intervalWidth = x * getScale + 20 + gap * getScale * (i + 1);
                    ctx.beginPath();
                    ctx.moveTo(intervalWidth, y * getScale + 20);

                    ctx.lineTo(intervalWidth, y * getScale + panelHeight * getScale + 20);
                    ctx.stroke();
                } else {
                    const intervalWidth = x * getScale + 20 + gap * getScale * (i + 1);
                    ctx.beginPath();
                    ctx.moveTo(
                        intervalWidth,
                        y * getScale + 20 - (panelHeight * getScale) / 5
                    );
                    ctx.lineTo(
                        intervalWidth,
                        y * getScale + 20 + (panelHeight * getScale) / 5
                    );

                    ctx.moveTo(
                        intervalWidth,
                        y * getScale +
                        20 -
                        (panelHeight * getScale) / 5 +
                        panelHeight * getScale
                    );
                    ctx.lineTo(
                        intervalWidth,
                        y * getScale +
                        20 +
                        (panelHeight * getScale) / 5 +
                        panelHeight * getScale
                    );
                    ctx.stroke();
                }
            });
        } else {
            const gap = panelHeight / (numRails + 1);

            repeat(numRails, (i) => {
                if (railContinuity === "Continuous") {
                    const intervalHeight = y * getScale + 20 + gap * getScale * (i + 1);
                    ctx.beginPath();
                    ctx.moveTo(x * getScale + 20, intervalHeight);

                    ctx.lineTo(x * getScale + panelWidth * getScale + 20, intervalHeight);
                    ctx.stroke();
                } else {
                    const intervalHeight = y * getScale + 20 + gap * getScale * (i + 1);
                    ctx.beginPath();
                    ctx.moveTo(
                        x * getScale + 20 - (panelWidth * getScale) / 5,
                        intervalHeight
                    );
                    ctx.lineTo(
                        x * getScale + 20 + (panelWidth * getScale) / 5,
                        intervalHeight
                    );

                    ctx.moveTo(
                        x * getScale +
                        20 -
                        (panelWidth * getScale) / 5 +
                        panelWidth * getScale,
                        intervalHeight
                    );
                    ctx.lineTo(
                        x * getScale +
                        20 +
                        (panelWidth * getScale) / 5 +
                        panelWidth * getScale,
                        intervalHeight
                    );
                    ctx.stroke();
                }
            });
        }
        ctx.strokeStyle = "black";
    }

    function calculateClamps(panelArray: number[][]): { midClamps: number; endClamps: number } {
        let midClamps = 0;
        let endClamps = 0;

        for (const row of panelArray) {
            let inSection = false;
            let panelCountInSection = 0;

            for (const panel of row) {
                if (panel) {
                    // We're inside a continuous section of panels
                    if (!inSection) {
                        inSection = true; // Start of a new section
                        endClamps += 2; // Add 2 end clamps for the section (start and end)
                    }
                    panelCountInSection++;
                } else if (inSection) {
                    // We just finished a continuous section of panels
                    midClamps += panelCountInSection - 1; // Mid clamp between every adjacent panel
                    panelCountInSection = 0;
                    inSection = false;
                }
            }

            // Handle the case where the section ends at the last panel
            if (inSection) {
                midClamps += panelCountInSection - 1;
            }
        }

        return {midClamps, endClamps};
    }


    // function drawClamps(
    //   panelWidth: number,
    //   panelHeight: number,
    //   panelsPerRow: number,
    //   actualRows: number
    // ) {
    //   return;
    //   ctx.fillStyle = "yellow";

    //   // Draw clamps on the top and bottom edges
    //   for (let col = 0; col <= panelsPerRow; col++) {
    //     const x = col * panelWidth;
    //     // Top edge
    //     ctx.fillRect(x * getScale + 15, 15, 10, 10);
    //     // Bottom edge
    //     ctx.fillRect(x * getScale + 15, layoutHeight * getScale + 25, 10, 10);
    //   }

    //   // Draw clamps on the left and right edges
    //   for (let row = 1; row < actualRows; row++) {
    //     const y = row * panelHeight;
    //     // Left edge
    //     ctx.fillRect(15, y * getScale + 15, 10, 10);
    //     // Right edge
    //     ctx.fillRect(layoutWidth * getScale + 25, y * getScale + 15, 10, 10);
    //   }

    //   ctx.fillStyle = "black";
    // }
</script>

<svelte:head>
    <title>Home</title>
    <meta name="description" content="Solar Panel Wizard"/>
</svelte:head>

<div class="ml-10">
    <div class="mt-10 flex space-x-4">
        <label class="inline">
            Run Orientation:
            <select
                    class="block w-full rounded-lg border border-gray-200 px-3 py-2 leading-6 focus:border-blue-500 focus:ring focus:ring-blue-500/50 dark:border-gray-600 dark:bg-gray-800 dark:focus:border-blue-500"
                    bind:value={runOrientation}
            >
                <option value="Columns">Columns / Vertical</option>
                <option value="Rows">Rows / Horizontal</option>
            </select>
        </label>

        <label>
            Panel Orientation:
            <select
                    class="block w-full rounded-lg border border-gray-200 px-3 py-2 leading-6 focus:border-blue-500 focus:ring focus:ring-blue-500/50 dark:border-gray-600 dark:bg-gray-800 dark:focus:border-blue-500"
                    bind:value={panelOrientation}
            >
                <option value="Landscape">Landscape</option>
                <option value="Portrait">Portrait</option>
            </select>
        </label>

        <label>
            Rail Orientation:
            <select
                    class="block w-full rounded-lg border border-gray-200 px-3 py-2 leading-6 focus:border-blue-500 focus:ring focus:ring-blue-500/50 dark:border-gray-600 dark:bg-gray-800 dark:focus:border-blue-500"
                    bind:value={railOrientation}
            >
                <option value="Parallel">Parallel to Run</option>
                <option value="Perpendicular">Perpendicular to Run</option>
            </select>
        </label>

        <label>
            Number of Rails:
            <input
                    class="block w-full rounded-lg border border-gray-200 px-3 py-2 leading-6 focus:border-blue-500 focus:ring focus:ring-blue-500/50 dark:border-gray-600 dark:bg-gray-800 dark:focus:border-blue-500"
                    type="number"
                    bind:value={numRails}
                    min="1"
                    max="5"
            />
        </label>

        <label>
            Rail Continuity:
            <select
                    class="block w-full rounded-lg border border-gray-200 px-3 py-2 leading-6 focus:border-blue-500 focus:ring focus:ring-blue-500/50 dark:border-gray-600 dark:bg-gray-800 dark:focus:border-blue-500"
                    bind:value={railContinuity}
            >
                <option value="Continuous">Continuous Rails</option>
                <option value="Short">Short Rails</option>
            </select>
        </label>
    </div>
    <div class="mt-1 flex space-x-4">
        <label>
            Length of Long Dimension (mm):
            <input
                    class="block w-full rounded-lg border border-gray-200 px-3 py-2 leading-6 focus:border-blue-500 focus:ring focus:ring-blue-500/50 dark:border-gray-600 dark:bg-gray-800 dark:focus:border-blue-500"
                    type="number"
                    bind:value={panelLongDimension}
                    min="100"
            />
        </label>

        <label>
            Length of Short Dimension (mm):
            <input
                    class="block w-full rounded-lg border border-gray-200 px-3 py-2 leading-6 focus:border-blue-500 focus:ring focus:ring-blue-500/50 dark:border-gray-600 dark:bg-gray-800 dark:focus:border-blue-500"
                    type="number"
                    bind:value={panelShortDimension}
                    min="100"
            />
        </label>

        <label>
            Panel Thickness (Not yet implemented):
            <input
                    class="block w-full rounded-lg border border-gray-200 px-3 py-2 leading-6 focus:border-blue-500 focus:ring focus:ring-blue-500/50 dark:border-gray-600 dark:bg-gray-800 dark:focus:border-blue-500"
                    type="number"
                    bind:value={panelThickness}
                    min="1"
            />
        </label>

        <label>
            Scale (0-100):
            <input
                    class="block w-full rounded-lg border border-gray-200 px-3 py-2 leading-6 focus:border-blue-500 focus:ring focus:ring-blue-500/50 dark:border-gray-600 dark:bg-gray-800 dark:focus:border-blue-500"
                    type="number"
                    bind:value={scale}
                    min="1"
                    max="100"
            />
        </label>
    </div>

    <div class="mt-1 flex space-x-4">
        <label>
            Number of Panels in run:
            <input
                    class="block w-full rounded-lg border border-gray-200 px-3 py-2 leading-6 focus:border-blue-500 focus:ring focus:ring-blue-500/50 dark:border-gray-600 dark:bg-gray-800 dark:focus:border-blue-500"
                    type="number"
                    bind:value={numPanels}
                    min="1"
                    max="1000"
            />
        </label>

        <label>
            Number of runs:
            <input
                    class="block w-full rounded-lg border border-gray-200 px-3 py-2 leading-6 focus:border-blue-500 focus:ring focus:ring-blue-500/50 dark:border-gray-600 dark:bg-gray-800 dark:focus:border-blue-500"
                    type="number"
                    bind:value={numberOfRuns}
                    min="1"
                    max="1000"
            />
        </label>
        <div style="margin-bottom: 10px;" class="self-end">
            <button
                    type="button"
                    class="inline-flex items-center justify-center gap-2 rounded-lg border border-blue-700 bg-blue-700 px-4 py-2 font-semibold leading-6 text-white hover:border-blue-600 hover:bg-blue-600 hover:text-white focus:ring focus:ring-blue-400/50 active:border-blue-700 active:bg-blue-700 dark:focus:ring-blue-400/90"
                    on:click={() => {
            let newRun = Array(numPanels).fill(1);
            let newRuns = Array(numberOfRuns).fill(newRun);
            panelArray = [...panelArray, ...newRuns];
          }}
            >
                <span>Add Runs</span>
                <svg
                        class="hi-mini hi-arrow-right inline-block size-5 opacity-50"
                        xmlns="http://www.w3.org/2000/svg"
                        viewBox="0 0 20 20"
                        fill="currentColor"
                        aria-hidden="true"
                >
                    <path
                            fill-rule="evenodd"
                            d="M3 10a.75.75 0 01.75-.75h10.638L10.23 5.29a.75.75 0 111.04-1.08l5.5 5.25a.75.75 0 010 1.08l-5.5 5.25a.75.75 0 11-1.04-1.08l4.158-3.96H3.75A.75.75 0 013 10z"
                            clip-rule="evenodd"
                    />
                </svg>
            </button>
        </div>
    </div>

    <div>
        <canvas
                style="background-color: #ffffff;"
                bind:this={canvas}
                on:wheel={(event) => {
          event.preventDefault();
          adjustScale(event.deltaY);
        }}
                width={canvasWidth}
                height={canvasHeight}
        ></canvas>
    </div>
</div>

<style>
    canvas {
        border: 1px solid #ccc;
    }

    div {
        margin-bottom: 20px;
    }

    label {
        display: block;
        margin-bottom: 10px;
    }
</style>
