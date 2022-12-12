package dev.pablomederos.composite.optionMenu

import androidx.compose.foundation.border
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Checkbox
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.mutableStateOf
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.unit.Dp

class OptionGroup(
    private val title: String,
    private val content: List<IOption>,
    private val callback: (state: Boolean, value: List<String>) -> Unit
) : IOption {

    private val isChecked = mutableStateOf(false)

    @Composable
    override fun CreateOption() {

        Column(
            modifier = Modifier
                .border(width = Dp(2f), color = Color.Red)
                .padding(all = Dp(10f))
        ) {
            Row {
                Checkbox(isChecked.value, onCheckedChange = { checkboxState ->
                    callback(
                        checkboxState,
                        select(checkboxState)
                    )
                })
                Text(text = title)
            }
            Row(
                Modifier
                    .padding(all = Dp(10f))) {
                Column(Modifier.padding(start = Dp(20f))) {
                    content.map { it.CreateOption() }
                }
            }
        }
    }

    override fun select(state: Boolean): List<String> {
        isChecked.value = state

        val result = mutableListOf<String>()

        content.forEach { it.select(state).forEach(result::add) }

        return result
    }
}